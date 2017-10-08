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

        public static Congregation MakeFakeHomeCongregation()
        {
            var self = new FakeModelFactory();
            return self.MakeHomeCongregation();
        }

        public static PmSchedule MakeFakePmSchedule()
        {
            var self = new FakeModelFactory();
            return self.MakePmSchedule();
        }

        public static ClmmSchedule MakeFakeClmmSchedule()
        {
            var self = new FakeModelFactory();
            return self.MakeClmmSchedule();
        }

        #endregion

        #region Behind the scenes-ish (can be used)

        public Congregation MakeHomeCongregation()
        {
            var homeCong = new Congregation
            {
                Name = new Faker().Address.City(),
                Members = MakeCongregationMembers(80)
            };
            return homeCong;
        }

        public ClmmSchedule MakeClmmSchedule()
        {
            var fakeMeeting = MakeMeeting();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Meeting, ClmmSchedule>());
            var mapper = config.CreateMapper();
            var fakeClmmSchedule = mapper.Map<ClmmSchedule>(fakeMeeting);

            var privileges = new Privileges { ClmmChairman = true };
            var fakeChairman = MakeCongMemberWithPrivileges(true, privileges);

            privileges = new Privileges { ClmmTreasures = true, ClmmPrayer = true };
            var fakeTreasuresBro = MakeCongMemberWithPrivileges(true, privileges);

            privileges = new Privileges { ClmmGems = true, ClmmLacParts = true, ClmmPrayer = true };
            var fakeGemsBro = MakeCongMemberWithPrivileges(true, privileges);

            privileges = new Privileges { ClmmBibleReading = true, ClmmCbsConductor = true };
            var fakeBibleReader = MakeCongMemberWithPrivileges(true, privileges);

            privileges = new Privileges { ClmmCbsReader = true, ClmmCbsConductor = true };
            var fakeCbsReader = MakeCongMemberWithPrivileges(true, privileges);

            fakeClmmSchedule.OpeningPrayer = fakeGemsBro;
            fakeClmmSchedule.Chairman = fakeChairman;
            fakeClmmSchedule.Treasures = fakeTreasuresBro;
            fakeClmmSchedule.Gems = fakeGemsBro;
            fakeClmmSchedule.BibleReading = fakeBibleReader;
            fakeClmmSchedule.InitialCall = MakeAssistedSchoolPart(true);
            fakeClmmSchedule.ReturnVisit = MakeAssistedSchoolPart(false);
            fakeClmmSchedule.BibleStudy = MakeAssistedSchoolPart(false);
            fakeClmmSchedule.LacPart1 = MakeMeetingPart(true);
            fakeClmmSchedule.LacPart2 = MakeMeetingPart(true);
            fakeClmmSchedule.CbsConductor = fakeBibleReader;
            fakeClmmSchedule.CbsReader = fakeCbsReader;
            fakeClmmSchedule.ClosingPrayer = fakeTreasuresBro;

            return fakeClmmSchedule;
        }

        public PmSchedule MakePmSchedule()
        {
            var fakeMeeting = MakeMeeting();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Meeting, PmSchedule>());
            var mapper = config.CreateMapper();
            var fakePmSchedule = mapper.Map<PmSchedule>(fakeMeeting);

            var privileges = new Privileges { PmChairman = true, WtReader = true };
            var fakeChairman = MakeCongMemberWithPrivileges(true, privileges);

            privileges = new Privileges { WtConductor = true };
            var fakeWtConductor = MakeCongMemberWithPrivileges(true, privileges);

            fakePmSchedule.Chairman = fakeChairman;
            fakePmSchedule.WtReader = fakeChairman;
            fakePmSchedule.WtConductor = fakeWtConductor;
            fakePmSchedule.PublicTalk = MakePublicTalk();

            return fakePmSchedule;
        }

        public CircuitVisitClmmSchedule MakeCircuitVisitClmmSchedule()
        {
            return null;
        }

        public CircuitVisitPmSchedule MakeCircuitVisitPmSchedule()
        {
            return null;
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
            fakeAssistedSchoolPart.Assistant = MakeCongMemberWithPrivileges(male, privileges);
            
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

        public Meeting MakeMeeting()
        {
            var privileges = new Privileges { Attendant = true, Security = true };
            var fakeAttendant = MakeCongMemberWithPrivileges(true, privileges);
            var fakeSecurityBro = MakeCongMemberWithPrivileges(true, privileges);

            privileges = new Privileges { Platform = true };
            var fakePlatformBro = MakeCongMemberWithPrivileges(true, privileges);

            privileges = new Privileges { RovingMic = true, SoundDesk = true };
            var fakeRovingMic1Bro = MakeCongMemberWithPrivileges(true, privileges);
            var fakeRovingMic2Bro = MakeCongMemberWithPrivileges(true, privileges);

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

        public Friend MakeCongMemberWithPrivileges(bool male, Privileges privileges)
        {
            var list = MakeCongregationMembers(1, privileges);
            var congMemberWithPrivileges = list.First();
            return congMemberWithPrivileges;
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
                visitingSpeaker.Congregation = MakeCongregations().First();
                fakeVisitingSpeakers.Add(visitingSpeaker);
            }
            return fakeVisitingSpeakers;
        }

        public List<Congregation> MakeCongregations(int count = 1)
        {
            var congFaker = CongregationFaker();

            var fakeCongregations = new List<Congregation>();
            while (count > 0)
            {
                fakeCongregations.Add((Congregation)congFaker);
                count--;
            }
            return fakeCongregations;
        }

        private Faker<Congregation> CongregationFaker()
        {
            var congFaker = new Faker<Congregation>()
                .RuleFor(c => c.Name, f => f.Name.FullName())
                .RuleFor(c => c.PublicTalkCoordinator, f => (Friend)MakeFriends().First());
            return congFaker;
        }

        public CircuitOverseer MakeCircuitOverseer()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Friend, CircuitOverseer>());
            var mapper = config.CreateMapper();
            var friend = MakeFriend();
            var co = mapper.Map<CircuitOverseer>(friend);
            co.Wife = MakeFriend();
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
                .RuleFor(p => p.Firstname, f => f.Name.FirstName())
                .RuleFor(p => p.Lastname, f => f.Name.LastName());
            return fakeFriend.Generate();
        }

        #endregion
    }
}
