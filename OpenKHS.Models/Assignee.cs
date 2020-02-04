using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using OpenKHS.Models.Attributes;

namespace OpenKHS.Models
{
    public class Assignee 
        : LookupEntry, IAssignee
    {
        private bool _ClmmChairman;
        private bool _SecondSchoolCounselor;
        private bool _Prayer;
        private bool _Treasures;
        private bool _Gems;
        private bool _SchoolBibleReading;
        private bool _SchoolDemo1;
        private bool _SchoolDemo2;
        private bool _SchoolDemo3;
        private bool _SchoolTalk;
        private bool _SchoolDemoHouseholder;
        private bool _SecondSchoolOnly;
        private bool _SchoolMainHallOnly;
        private bool _LacParts;
        private bool _CbsConductor;
        private bool _CbsReader;
        private bool _PublicSpeaker;
        private bool _AwaySpeaker;
        private bool _PmChairman;
        private bool _WtReader;
        private bool _Attendant;
        private bool _Platform;
        private bool _SoundDesk;
        private bool _RovingMic;
        private bool _WtConductor;

        public Assignee()
        {
            Assignments = new List<Assignment>();
        }

        public IList<Assignment> Assignments { get; set; }

        #region Privileges

        [Privilege]
        public bool ClmmChairman
        {
            get => _ClmmChairman;
            set => Set(ref _ClmmChairman, value);
        }

        [Privilege]
        public bool SecondSchoolCounselor
        {
            get => _SecondSchoolCounselor;
            set => Set(ref _SecondSchoolCounselor, value);
        }

        [Privilege]
        public bool Treasures
        {
            get => _Treasures;
            set => Set(ref _Treasures, value);
        }

        [Privilege]
        public bool Gems
        {
            get => _Gems;
            set => Set(ref _Gems, value);
        }

        [Privilege]
        public bool SchoolBibleReading
        {
            get => _SchoolBibleReading;
            set => Set(ref _SchoolBibleReading, value);
        }

        [Privilege]
        public bool SchoolDemo1
        {
            get => _SchoolDemo1;
            set => Set(ref _SchoolDemo1, value);
        }

        [Privilege]
        public bool SchoolDemo2
        {
            get => _SchoolDemo2;
            set => Set(ref _SchoolDemo2, value);
        }

        [Privilege]
        public bool SchoolDemo3
        {
            get => _SchoolDemo3;
            set => Set(ref _SchoolDemo3, value);
        }

        [Privilege]
        public bool SchoolTalk
        {
            get => _SchoolTalk;
            set => Set(ref _SchoolTalk, value);
        }

        [Privilege]
        public bool SchoolDemoHouseholder
        {
            get => _SchoolDemoHouseholder;
            set => Set(ref _SchoolDemoHouseholder, value);
        }

        [Privilege]
        public bool SecondSchoolOnly
        {
            get => _SecondSchoolOnly;
            set => Set(ref _SecondSchoolOnly, value);
        }

        [Privilege]
        public bool SchoolMainHallOnly
        {
            get => _SchoolMainHallOnly;
            set => Set(ref _SchoolMainHallOnly, value);
        }

        [Privilege]
        public bool LacParts
        {
            get => _LacParts;
            set => Set(ref _LacParts, value);
        }

        [Privilege]
        public bool CbsConductor
        {
            get => _CbsConductor;
            set => Set(ref _CbsConductor, value);
        }

        [Privilege]
        public bool CbsReader
        {
            get => _CbsReader;
            set => Set(ref _CbsReader, value);
        }

        [Privilege]
        public bool PublicSpeaker
        {
            get => _PublicSpeaker;
            set => Set(ref _PublicSpeaker, value);
        }

        [Privilege]
        public bool AwaySpeaker
        {
            get => _AwaySpeaker;
            set => Set(ref _AwaySpeaker, value);
        }

        [Privilege]
        public bool PmChairman
        {
            get => _PmChairman;
            set => Set(ref _PmChairman, value);
        }

        [Privilege]
        public bool Prayer
        {
            get => _Prayer;
            set => Set(ref _Prayer, value);
        }

        [Privilege]
        public bool WtReader
        {
            get => _WtReader;
            set => Set(ref _WtReader, value);
        }

        [Privilege]
        public bool Attendant
        {
            get => _Attendant;
            set => Set(ref _Attendant, value);
        }

        [Privilege]
        public bool SoundDesk
        {
            get => _SoundDesk;
            set => Set(ref _SoundDesk, value);
        }

        [Privilege]
        public bool Platform
        {
            get => _Platform;
            set => Set(ref _Platform, value);
        }

        [Privilege]
        public bool RovingMic
        {
            get => _RovingMic;
            set => Set(ref _RovingMic, value);
        }

        [Privilege]
        public bool WtConductor
        {
            get => _WtConductor;
            set => Set(ref _WtConductor, value);
        }


        public int CountPrivileges()
        {
            var count = 0;
            var privileges = GetType().GetProperties()
                .Where(p => Attribute.IsDefined(
                    p, typeof(PrivilegeAttribute)));
            foreach (var privilege in privileges)
            {
                var val = privilege.GetValue(this);
                if (val is bool && (bool)val) count++;
            }
            return count;
        }

        public bool CanAcceptAssignmentType(AssignmentType assignmentType)
        {
            // TODO also include logic for 2nd school only property and main hall only prop
            var value = assignmentType?.Name switch
            {
                nameof(Attendant) => Attendant,
                nameof(AwaySpeaker) => AwaySpeaker,
                nameof(SchoolBibleReading) => SchoolBibleReading,
                nameof(CbsConductor) => CbsConductor,
                nameof(CbsReader) => CbsReader,
                nameof(ClmmChairman) => ClmmChairman,
                nameof(Gems) => Gems,
                nameof(LacParts) => LacParts,
                nameof(SchoolMainHallOnly) => SchoolMainHallOnly,
                nameof(SchoolDemoHouseholder) => SchoolDemoHouseholder,
                nameof(SchoolDemo3) => SchoolDemo3,
                nameof(SchoolDemo1) => SchoolDemo1,
                nameof(SchoolDemo2) => SchoolDemo2,
                nameof(SchoolTalk) => SchoolTalk,
                nameof(SecondSchoolCounselor) => SecondSchoolCounselor,
                nameof(SecondSchoolOnly) => SecondSchoolOnly,
                nameof(Treasures) => Treasures,
                nameof(Platform) => Platform,
                nameof(PmChairman) => PmChairman,
                nameof(Prayer) => Prayer,
                nameof(PublicSpeaker) => PublicSpeaker,
                nameof(RovingMic) => RovingMic,
                nameof(SoundDesk) => SoundDesk,
                nameof(WtConductor) => WtConductor,
                nameof(WtReader) => WtReader,
                _ => false
            };
            return value;
        }

        #endregion

        [NotMapped]
        public new static Assignee Empty => new NullAssignee();

    }

    public class NullAssignee : Assignee
    {
        public new int Id = LookupEntry.Empty.Id;

        public new string Name = LookupEntry.Empty.Name;
    }

}
