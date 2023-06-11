using dj_webdesigncore.Entities.UserEntity;
using dj_webdesigncore.Enums.Else;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dj_webdesigncore.Entities.BusinessEntity
{
    public class Denounce : BaseEntity
    {
        public int UserSendId { get; set; }
        public User UserSend { get; set; }
        public int UserViolationId { get; set; }
        public string ProveLink { get; set; }
        [DefaultValue(false)]
        public bool IsCheck { get; set; }
        public DateTime SendTime { get; set; }
        public DateTime? CheckTime { get; set; }
        public bool IsViolation { get; set; }
        public string? Note { get; set; }
        public int CmtId { get; set; }
        public int? DenounceTypeId { get; set; }
        public DenounceType? DenounceType { get; set; }
        public TypeCmt? TypeCmt { get; set; }
        public int? UserCheckId { get; set; }
    }
}
