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

        public static LocalCongregation MakeFakeCongregation()
        {
            var self = new FakeModelFactory();
            return self.MakeCongregation();
        }

        #endregion

        #region Behind the scenes-ish (can be used)

        public LocalCongregation MakeCongregation(int members = 80)
        {
            var homeCong = new LocalCongregation(MakeCongregationMembers(members));
            return homeCong;
        }

        public PublicTalk MakePublicTalk()
        {
            var speaker = MakeVisitingSpeakers(1).First();
            var publicTalk = new PublicTalk
            {
                Id = new Faker().Random.Number(1, 194),
                VisitingSpeaker = speaker,
                Name = "Fake Talk"
            };
            return publicTalk;
        }

        public LocalCongregationMember MakeCongMemberWithPrivileges(List<string> privileges)
        {
            var list = MakeCongregationMembersWithPrivildeges(1, privileges);
            var congMemberWithPrivileges = list.First();
            return congMemberWithPrivileges;
        }

        public LocalCongregationMember MakeCongMemberWithAssignmentTally()
        {
            var list = MakeCongregationMembers(1);
            var congMember = list.First();
            congMember.MeetingAssignmentTally = (uint)new Faker().Random.Number(5);
            return congMember;
        }

        public LocalCongregationMember MakeCongMemberWithUnavailablePeriods()
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LocalCongregationMember, VisitingSpeaker>());
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LocalCongregationMember, CircuitOverseer>());
            var mapper = config.CreateMapper();
            var friend = MakeCongregationMember();
            var co = mapper.Map<CircuitOverseer>(friend);
            co.Wife = new Faker().Name.FullName();
            return co;
        }

        public List<LocalCongregationMember> MakeCongregationMembersWithPrivildeges(int count = 1, List<string> privileges = null)
        {
            var fakeCongregationMembers = MakeCongregationMembers(count);

            var list = new List<LocalCongregationMember>();

            foreach (var fakeCongregationMember in fakeCongregationMembers)
            {
                LocalCongregationMember friendWithFakePrivileges;
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

        public LocalCongregationMember AddPrivileges(LocalCongregationMember friend, List<string> privileges)
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
                        friend.Prayer = true;
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

        public LocalCongregationMember AddRandomPrivileges(LocalCongregationMember friend, bool male = false)
        {
            if (male)
            {
                friend.Prayer = TheBogusRandomBoolWontWorkSoIveCreatedMyOwn();
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

        public List<LocalCongregationMember> MakeCongregationMembers(int count = 1)
        {
            var friends = new List<LocalCongregationMember>();
            while (count > 0)
            {
                friends.Add(MakeCongregationMember());
                count--;
            }
            return friends;
        }


        private LocalCongregationMember MakeCongregationMember()
        {
            var fakeCongregationMember = new Faker<LocalCongregationMember>()
                .RuleFor(p => p.Name, f => f.Name.FullName());
            return fakeCongregationMember.Generate();
        }

        #endregion
    }
}
