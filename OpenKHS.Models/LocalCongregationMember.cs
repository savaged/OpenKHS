﻿using System;
using System.Linq;
using OpenKHS.Models.Attributes;

namespace OpenKHS.Models
{
    public class LocalCongregationMember : Lookup, ILocalCongregationMember
    {
        private bool _ClmmChairman;
        private bool _ClmmSecondSchoolCounselor;
        private bool _Prayer;
        private bool _ClmmTreasures;
        private bool _ClmmGems;
        private bool _ClmmBibleReading;
        private bool _ClmmSchoolInitialCall;
        private bool _ClmmSchoolReturnVisit;
        private bool _ClmmSchoolBibleStudy;
        private bool _ClmmSchoolTalk;
        private bool _ClmmSchoolAssistant;
        private bool _ClmmSecondSchoolOnly;
        private bool _ClmmMainHallOnly;
        private bool _ClmmLacParts;
        private bool _ClmmCbsConductor;
        private bool _ClmmCbsReader;
        private bool _PublicSpeaker;
        private bool _AwaySpeaker;
        private bool _PmChairman;
        private bool _WtReader;
        private bool _Attendant;
        private bool _Security;
        private bool _SoundDesk;
        private bool _Platform;
        private bool _RovingMic;
        private bool _WtConductor;
        private bool _MainWtConductor;

        public LocalCongregationMember()
        {
            
        }

        #region Privileges

        [Privilege]
        public bool ClmmChairman
        {
            get => _ClmmChairman;
            set => Set(ref _ClmmChairman, value);
        }

        [Privilege]
        public bool ClmmSecondSchoolCounselor
        {
            get => _ClmmSecondSchoolCounselor;
            set => Set(ref _ClmmSecondSchoolCounselor, value);
        }

        [Privilege]
        public bool ClmmTreasures
        {
            get => _ClmmTreasures;
            set => Set(ref _ClmmTreasures, value);
        }

        [Privilege]
        public bool ClmmGems
        {
            get => _ClmmGems;
            set => Set(ref _ClmmGems, value);
        }

        [Privilege]
        public bool ClmmBibleReading
        {
            get => _ClmmBibleReading;
            set => Set(ref _ClmmBibleReading, value);
        }

        [Privilege]
        public bool ClmmSchoolInitialCall
        {
            get => _ClmmSchoolInitialCall;
            set => Set(ref _ClmmSchoolInitialCall, value);
        }

        [Privilege]
        public bool ClmmSchoolReturnVisit
        {
            get => _ClmmSchoolReturnVisit;
            set => Set(ref _ClmmSchoolReturnVisit, value);
        }

        [Privilege]
        public bool ClmmSchoolBibleStudy
        {
            get => _ClmmSchoolBibleStudy;
            set => Set(ref _ClmmSchoolBibleStudy, value);
        }

        [Privilege]
        public bool ClmmSchoolTalk
        {
            get => _ClmmSchoolTalk;
            set => Set(ref _ClmmSchoolTalk, value);
        }

        [Privilege]
        public bool ClmmSchoolAssistant
        {
            get => _ClmmSchoolAssistant;
            set => Set(ref _ClmmSchoolAssistant, value);
        }

        [Privilege]
        public bool ClmmSecondSchoolOnly
        {
            get => _ClmmSecondSchoolOnly;
            set => Set(ref _ClmmSecondSchoolOnly, value);
        }

        [Privilege]
        public bool ClmmMainHallOnly
        {
            get => _ClmmMainHallOnly;
            set => Set(ref _ClmmMainHallOnly, value);
        }

        [Privilege]
        public bool ClmmLacParts
        {
            get => _ClmmLacParts;
            set => Set(ref _ClmmLacParts, value);
        }

        [Privilege]
        public bool ClmmCbsConductor
        {
            get => _ClmmCbsConductor;
            set => Set(ref _ClmmCbsConductor, value);
        }

        [Privilege]
        public bool ClmmCbsReader
        {
            get => _ClmmCbsReader;
            set => Set(ref _ClmmCbsReader, value);
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
        public bool Security
        {
            get => _Security;
            set => Set(ref _Security, value);
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

        [Privilege]
        public bool MainWtConductor
        {
            get => _MainWtConductor;
            set => Set(ref _MainWtConductor, value);
        }


        public int CountPrivileges()
        {
            var count = 0;
            var privileges = GetType().GetProperties().Where(p => Attribute.IsDefined(p, typeof(PrivilegeAttribute)));
            foreach (var privilege in privileges)
            {
                var val = privilege.GetValue(this);
                if (val is bool && (bool)val) count++;
            }
            return count;
        }

        #endregion

    }

    public class NullLocalCongregationMember : LocalCongregationMember
    {
        public new int Id = Lookup.Empty.Id;

        public new string Name = Lookup.Empty.Name;
    }

}
