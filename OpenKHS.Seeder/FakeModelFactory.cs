using AutoMapper;
using Bogus;
using OpenKHS.Interfaces;
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

            var privileges = new List<string>
            {
                "ClmmSchoolAssistant",
                "ClmmSchoolInitialCall",
                "ClmmSchoolReturnVisit",
                "ClmmSchoolBibleStudy"
            };
            fakeAssistedSchoolPart.Assistant = MakeCongMemberWithPrivileges(privileges);
            
            return fakeAssistedSchoolPart;
        }

        public SchoolMeetingPart MakeSchoolPart(bool male)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MeetingPart, SchoolMeetingPart>());
            var mapper = config.CreateMapper();

            var fakeSchoolMeetingPart = mapper.Map<SchoolMeetingPart>(MakeMeetingPart());

            fakeSchoolMeetingPart.CounselPoint = new Faker().Random.Number(1, 53);

            return fakeSchoolMeetingPart;
        }

        public MeetingPart MakeMeetingPart()
        {
            var fakeMeetingPart = new MeetingPart
            {
                Title = new Faker().Random.Words(4),
                Friend = MakeCongregationMembers(1).First()
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

        public CongregationMember MakeCongMemberWithPrivileges(List<string> privileges)
        {
            var list = MakeCongregationMembersWithPrivildeges(1, privileges);
            var congMemberWithPrivileges = list.First();
            return congMemberWithPrivileges;
        }

        public CongregationMember MakeCongMemberWithAssignmentTally()
        {
            var list = MakeCongregationMembers(1);
            var congMember = list.First();
            congMember.MeetingAssignmentTally = (uint)new Faker().Random.Number(5);
            return congMember;
        }

        public CongregationMember MakeCongMemberWithUnavailablePeriods()
        {
            var list = MakeCongregationMembers(1);
            var congMember = list.First();
            congMember.UnavailablePeriods = new List<DateRange>
            {
                new DateRange(new DateTime(2018, 04, 01), DateTime.Now)
            };
            return congMember;
        }

        public List<VisitingSpeaker> MakeVisitingSpeakers(int count = 1)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CongregationMember, VisitingSpeaker>());
            var mapper = config.CreateMapper();

            var fakeCongregationMembers = MakeCongregationMembers(count);

            var fakeVisitingSpeakers = new List<VisitingSpeaker>();

            foreach (var fakeCongregationMember in fakeCongregationMembers)
            {
                var visitingSpeaker = mapper.Map<VisitingSpeaker>(fakeCongregationMember);
                visitingSpeaker.Congregation = "Another congregation";
                fakeVisitingSpeakers.Add(visitingSpeaker);
            }
            return fakeVisitingSpeakers;
        }

        public CircuitOverseer MakeCircuitOverseer()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CongregationMember, CircuitOverseer>());
            var mapper = config.CreateMapper();
            var friend = MakeCongregationMember();
            var co = mapper.Map<CircuitOverseer>(friend);
            co.Wife = new Faker().Name.FullName();
            return co;
        }

        public List<CongregationMember> MakeCongregationMembersWithPrivildeges(int count = 1, List<string> privileges = null)
        {
            var fakeCongregationMembers = MakeCongregationMembers(count);

            var list = new List<CongregationMember>();

            foreach (var fakeCongregationMember in fakeCongregationMembers)
            {
                CongregationMember friendWithFakePrivileges;
                if (privileges is null)
                {
                    friendWithFakePrivileges = AddRandomPrivileges(fakeCongregationMember);
                }
                else
                {
                    friendWithFakePrivileges = AddPrivileges(fakeCongregationMember, privileges);
                }
                list.Add(friendWithFakePrivileges);
            }
            return list;
        }

        public CongregationMember AddPrivileges(CongregationMember friend, List<string> privileges)
        {
            foreach (var privilege in privileges)
            {
                switch (privilege)
                {
                    case "Attendant":
                        friend.Attendant = true;
                        break;
                    case "AwaySpeaker":
                        friend.AwaySpeaker = true;
                        break;
                    case "ClmmBibleReading":
                        friend.ClmmBibleReading = true;
                        break;
                    case "ClmmCbsConductor":
                        friend.ClmmCbsConductor = true;
                        break;
                    case "ClmmCbsReader":
                        friend.ClmmCbsReader = true;
                        break;
                    case "ClmmChairman":
                        friend.ClmmChairman = true;
                        break;
                    case "ClmmGems":
                        friend.ClmmGems = true;
                        break;
                    case "ClmmLacParts":
                        friend.ClmmLacParts = true;
                        break;
                    case "ClmmMainHallOnly":
                        friend.ClmmMainHallOnly = true;
                        break;
                    case "ClmmPrayer":
                        friend.ClmmPrayer = true;
                        break;
                    case "ClmmSchoolAssistant":
                        friend.ClmmSchoolAssistant = true;
                        break;
                    case "ClmmSchoolBibleStudy":
                        friend.ClmmSchoolBibleStudy = true;
                        break;
                    case "ClmmSchoolInitialCall":
                        friend.ClmmSchoolInitialCall = true;
                        break;
                    case "ClmmSchoolMonthPresentations":
                        friend.ClmmSchoolMonthPresentations = true;
                        break;
                    case "ClmmSchoolReturnVisit":
                        friend.ClmmSchoolReturnVisit = true;
                        break;
                    case "ClmmSecondSchoolCounselor":
                        friend.ClmmSchoolTalk = true;
                        break;
                    case "":
                        friend.ClmmSecondSchoolCounselor = true;
                        break;
                    case "ClmmSecondSchoolOnly":
                        friend.ClmmSecondSchoolOnly = true;
                        break;
                    case "ClmmTreasures":
                        friend.ClmmTreasures = true;
                        break;
                    case "Platform":
                        friend.Platform = true;
                        break;
                    case "PmChairman":
                        friend.PmChairman = true;
                        break;
                    case "PublicSpeaker":
                        friend.PublicSpeaker = true;
                        break;
                    case "RovingMic":
                        friend.RovingMic = true;
                        break;
                    case "Security":
                        friend.Security = true;
                        break;
                    case "SoundDesk":
                        friend.SoundDesk = true;
                        break;
                    case "WtConductor":
                        friend.WtConductor = true;
                        break;
                    case "WtReader":
                        friend.WtReader = true;
                        break;
                }
            }
            return friend;
        }

        public CongregationMember AddRandomPrivileges(CongregationMember friend, bool male = false)
        {
            if (male)
            {
                friend.ClmmPrayer = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                friend.ClmmLacParts = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                friend.Platform = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                friend.Attendant = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                friend.Security = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                friend.SoundDesk = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                friend.ClmmTreasures = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                friend.ClmmChairman = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                friend.ClmmCbsConductor = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                friend.ClmmSchoolBibleStudy = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                friend.ClmmSchoolInitialCall = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                friend.ClmmSchoolReturnVisit = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                friend.ClmmSchoolTalk = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                friend.ClmmCbsReader = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                friend.ClmmSchoolMonthPresentations = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                friend.ClmmGems = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                friend.WtReader = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                friend.AwaySpeaker = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
            }
            else
            {
                friend.ClmmSchoolBibleStudy = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                friend.ClmmSchoolInitialCall = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                friend.ClmmSchoolReturnVisit = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
                friend.ClmmSecondSchoolOnly = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
            }
            return friend;
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

        public List<CongregationMember> MakeCongregationMembers(int count = 1)
        {
            var friends = new List<CongregationMember>();
            while (count > 0)
            {
                friends.Add(MakeCongregationMember());
                count--;
            }
            return friends;
        }
        

        private CongregationMember MakeCongregationMember()
        {
            var fakeCongregationMember = new Faker<CongregationMember>()
                .RuleFor(p => p.Name, f => f.Name.FullName());
            return fakeCongregationMember.Generate();
        }

        #endregion
    }
}
