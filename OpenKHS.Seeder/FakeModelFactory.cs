using AutoMapper;
using Bogus;
using OpenKHS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenKHS.Seeder
{
    public class FakeModelFactory
    {
        #region set-up

        public FakeModelFactory() => Randomizer.Seed = new Random(8675309);

        #endregion

        #region Main API / Helper methods

        public static Congregation MakeFakeCongregation()
        {
            var self = new FakeModelFactory();
            return self.MakeCongregation();
        }

        #endregion

        #region Behind the scenes-ish (can be used)

        public Congregation MakeCongregation(int members = 80)
        {
            var homeCong = new Congregation
            {
                Members = MakeCongregationMembers(members)
            };
            return homeCong;
        }

        public AssistedSchoolMeetingPart MakeAssistedSchoolPart(bool male)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SchoolMeetingPart, AssistedSchoolMeetingPart>());
            var mapper = config.CreateMapper();

            var schoolMeetingPart = MakeSchoolPart(male);

            var fakeAssistedSchoolPart = mapper.Map<AssistedSchoolMeetingPart>(schoolMeetingPart);

            var privileges = new Privileges
            {
                ClmmSchoolAssistant = true,
                ClmmSchoolInitialCall = true,
                ClmmSchoolReturnVisit = true,
                ClmmSchoolBibleStudy = true
            };
            fakeAssistedSchoolPart.Assistant = MakeCongMemberWithPrivileges(privileges);
            
            return fakeAssistedSchoolPart;
        }

        public SchoolMeetingPart MakeSchoolPart(bool male)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MeetingPart, SchoolMeetingPart>());
            var mapper = config.CreateMapper();

            var fakeSchoolMeetingPart = mapper.Map<SchoolMeetingPart>(MakeMeetingPart(male));

            var privileges = new Privileges();
            if (male)
            {
                privileges.ClmmSchoolTalk = privileges.ClmmBibleReading = true;
            }
            fakeSchoolMeetingPart.CounselPoint = new Faker().Random.Number(1, 53);

            return fakeSchoolMeetingPart;
        }

        public MeetingPart MakeMeetingPart(bool male = true)
        {
            var fakeMeetingPart = new MeetingPart
            {
                Title = new Faker().Random.Words(4),
                Friend = MakeFriends(1).First()
            };
            return fakeMeetingPart;
        }

        /*
         public Meeting MakeMeeting()
        {
            var privileges = new Privileges { Attendant = true, Security = true };
            var fakeAttendant = MakeCongMemberWithPrivileges(privileges);
            var fakeSecurityBro = MakeCongMemberWithPrivileges(privileges);

            privileges = new Privileges { Platform = true };
            var fakePlatformBro = MakeCongMemberWithPrivileges(privileges);

            privileges = new Privileges { RovingMic = true, SoundDesk = true };
            var fakeRovingMic1Bro = MakeCongMemberWithPrivileges(privileges);
            var fakeRovingMic2Bro = MakeCongMemberWithPrivileges(privileges);

            var fakeMeeting = new Meeting
            {
                Attendant = fakeAttendant,
                Security = fakeSecurityBro,
                Platform = fakePlatformBro,
                RovingMic1 = fakeRovingMic1Bro,
                RovingMic2 = fakeRovingMic2Bro,
                SoundDesk = fakeRovingMic1Bro,
                
                Week = new Faker().Random.Number(1, 52)
            };
            return fakeMeeting;
        }
        */

        public PublicTalk MakePublicTalk()
        {
            var speaker = MakeVisitingSpeakers(1).First();
            var publicTalk = new PublicTalk
            {
                TalkNumber = new Faker().Random.Number(1, 194),
                Friend = speaker
            };
            return publicTalk;
        }

        public Friend MakeCongMemberWithPrivileges(Privileges privileges)
        {
            var list = MakeCongregationMembers(1, privileges);
            var congMemberWithPrivileges = list.First();
            return congMemberWithPrivileges;
        }

        public Friend MakeCongMemberWithAssignmentTally()
        {
            var list = MakeCongregationMembers(1);
            var congMember = list.First();
            congMember.AssignmentTally = new Faker().Random.Number(5);
            return congMember;
        }

        public List<VisitingSpeaker> MakeVisitingSpeakers(int count = 1)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Friend, VisitingSpeaker>());
            var mapper = config.CreateMapper();

            var fakeFriends = MakeFriends(count);

            var fakeVisitingSpeakers = new List<VisitingSpeaker>();

            foreach (var fakeFriend in fakeFriends)
            {
                var visitingSpeaker = mapper.Map<VisitingSpeaker>(fakeFriend);
                visitingSpeaker.Congregation = "Another congregation";
                fakeVisitingSpeakers.Add(visitingSpeaker);
            }
            return fakeVisitingSpeakers;
        }

        public CircuitOverseer MakeCircuitOverseer()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Friend, CircuitOverseer>());
            var mapper = config.CreateMapper();
            var friend = MakeFriend();
            var co = mapper.Map<CircuitOverseer>(friend);
            co.Wife = new Faker().Name.FullName();
            return co;
        }

        public List<Friend> MakeCongregationMembers(int count = 1, Privileges privileges = null)
        {
            var fakeFriends = MakeFriends(count);

            var fakeCongregationMembers = new List<Friend>();

            foreach (var fakeFriend in fakeFriends)
            {
                if (privileges is null)
                {
                    fakeFriend.Privileges = MakeRandomPrivileges();
                }
                else
                {
                    fakeFriend.Privileges = privileges;
                }
                fakeCongregationMembers.Add(fakeFriend);
            }
            return fakeCongregationMembers;
        }

        public Privileges MakeRandomPrivileges(bool male = false)
        {
            
            Faker<Privileges> privilegesFaker;
            if (male)
            {
                privilegesFaker = new Faker<Privileges>()
                    .Rules((f, p) => {
                        p.ClmmPrayer = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                        p.ClmmLacParts = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                        p.Platform = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                        p.Attendant = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                        p.Security = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                        p.SoundDesk = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                        p.ClmmTreasures = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                        p.ClmmChairman = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                        p.ClmmCbsConductor = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                        p.ClmmSchoolBibleStudy = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                        p.ClmmSchoolInitialCall = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                        p.ClmmSchoolReturnVisit = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                        p.ClmmSchoolTalk = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                        p.ClmmCbsReader = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                        p.ClmmSchoolMonthPresentations = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                        p.ClmmGems = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                        p.WtReader = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                        p.AwaySpeaker = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                    });
            }
            else
            {
                privilegesFaker = new Faker<Privileges>()
                    .Rules((f, p) => {
                        p.ClmmSchoolBibleStudy = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                        p.ClmmSchoolInitialCall = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                        p.ClmmSchoolReturnVisit = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                        p.ClmmSecondSchoolOnly = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                    });
            }
            var fakePrivileges = (Privileges)privilegesFaker;
            return fakePrivileges;
        }

        private bool TheBogusRandomBoolWontWorkSoIveCreatedMyOwn()
        {
            bool b = false;
            string binString = Convert.ToString(Randomizer.Seed.Next(2), 2); 
            string c = binString[binString.Length - 1].ToString();
            int i = Int32.Parse(c);
            b = 0 != i;
            return b;
        }

        public List<Friend> MakeFriends(int count = 1)
        {
            var friends = new List<Friend>();
            while (count > 0)
            {
                friends.Add(MakeFriend());
                count--;
            }
            return friends;
        }
        

        private Friend MakeFriend()
        {
            var fakeFriend = new Faker<Friend>()
                .RuleFor(p => p.Name, f => f.Name.FullName());
            return fakeFriend.Generate();
        }

        #endregion
    }
}
