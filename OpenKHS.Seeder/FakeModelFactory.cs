using AutoMapper;
using Bogus;
using OpenKHS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenKHS.Seeder
{
    public enum Gender
    {
        Male,
        Female,
        Random
    }

    public class FakeModelFactory
    {
        #region set-up

        public FakeModelFactory() => Randomizer.Seed = new Random(8675309);

        #endregion

        public ClmmSchedule MakeClmmSchedule()
        {
            return null;
        }

        public PmSchedule MakePmSchedule()
        {
            var fakeAttendantPrivileges = new Privileges { Attendant = true };
            var fakeAttendant = MakeCongMemberWithPrivileges(true, fakeAttendantPrivileges);

            var fakePmSchedule = new PmSchedule
            {
                Attendant = fakeAttendant
            };
            return null;
        }

        public PmSchedule MakeCircuitVisitClmmSchedule()
        {
            return null;
        }

        public PmSchedule MakeCircuitVisitPmSchedule()
        {
            return null;
        }

        public CongregationMember MakeCongMemberWithPrivileges(bool male, Privileges privileges)
        {
            var congMemberWithPrivileges = MakeCongMemberWithPrivileges(male, privileges);
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
                .StrictMode(true)
                .RuleFor(c => c.Name, f => f.Name.FullName())
                .RuleFor(c => c.PublicTalkCoordinator, f => (Friend)MakeFriends().First());
            return congFaker;
        }

        public CircuitOverseer MakeCircuitOverseer()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Friend, CircuitOverseer>());
            var mapper = config.CreateMapper();

            var co = mapper.Map<CircuitOverseer>((Friend)FriendFaker(Gender.Male));
            co.Wife = (Friend)FriendFaker(Gender.Female);
            return co;
        }

        public List<CongregationMember> MakeCongregationMember(int count = 1, Privileges privileges = null)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Friend, CongregationMember>());
            var mapper = config.CreateMapper();

            var fakeFriends = MakeFriends(count);

            var fakeCongregationMembers = new List<CongregationMember>();

            foreach (var fakeFriend in fakeFriends)
            {
                var congregationMember = mapper.Map<CongregationMember>(fakeFriend);
                if (privileges is null)
                {
                    congregationMember.Privileges = MakeRandomPrivileges(congregationMember.Male);
                }
                else
                {
                    congregationMember.Privileges = privileges;
                }
                fakeCongregationMembers.Add(congregationMember);
            }
            return fakeCongregationMembers;
        }

        public Privileges MakeRandomPrivileges(bool male)
        {
            Faker<Privileges> privilegesFaker;
            if (male)
            {
                privilegesFaker = new Faker<Privileges>()
                    .Rules((f, p) => {
                        p.ClmmPrayer = p.ClmmLacParts = p.Platform = p.Attendant = p.Security = p.SoundDesk = f.Random.Bool();
                        p.ClmmTreasures = p.ClmmChairman = p.ClmmCbsConductor = f.Random.Bool();
                        p.ClmmBAyfmiBibleStudy = p.ClmmAyfmInitialCall = p.ClmmAyfmReturnVisit = p.ClmmAyfmTalk = f.Random.Bool();
                        p.ClmmCbsReader = p.ClmmAyfmMonthPresentations = p.ClmmGems = f.Random.Bool();
                        p.WtReader = p.AwaySpeaker = f.Random.Bool();
                    });
            }
            else
            {
                privilegesFaker = new Faker<Privileges>()
                    .Rules((f, p) => {
                        p.ClmmBAyfmiBibleStudy = p.ClmmAyfmInitialCall = p.ClmmAyfmReturnVisit = f.Random.Bool();
                        p.ClmmSecondSchoolOnly = f.Random.Bool();
                    });
            }
            return privilegesFaker.Generate();
        }

        public List<Friend> MakeFriends(int count = 1)
        {
            var friendFaker = FriendFaker(Gender.Random);

            var fakeFriends = new List<Friend>();
            while (count > 0)
            {
                fakeFriends.Add((Friend)friendFaker);
                count--;
            }
            return fakeFriends;
        }

        private Faker<Friend> FriendFaker(Gender gender)
        {
            var fakeFriend = new Faker<Friend>()
                .StrictMode(true)
                .RuleFor(p => p.Firstname, f => f.Name.FirstName())
                .RuleFor(p => p.Lastname, f => f.Name.LastName())
                .RuleFor(p => p.Mobile, f => new Person().Phone)
                .RuleFor(p => p.Landline, f => new Person().Phone)
                .RuleFor(p => p.Email, (f, p) => f.Internet.Email(p.Firstname, p.Lastname))
                .RuleFor(p => p.Male, f => GetGender(gender));
            return fakeFriend;
        }

        private bool GetGender(Gender gender)
        {
            bool male = true;
            switch (gender)
            {
                case Gender.Male:
                    male = true;
                    break;
                case Gender.Female:
                    male = false;
                    break;
                case Gender.Random:
                    male = new Faker().Random.Bool();
                    break;
                default:
                    break;
            }
            return male;
        }
    }
}
