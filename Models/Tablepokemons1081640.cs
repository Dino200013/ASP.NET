//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace prj1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Tablepokemons1081640
    {
        [DisplayName("寶可夢ID")]
        [RegularExpression("^[0-9]*$", ErrorMessage ="只能輸入數字")]
        public string pId { get; set; }

        [DisplayName("圖片")]
        public string pImg { get; set; }

        [DisplayName("名字")]

        public string pName { get; set; }

        [DisplayName("屬性")]

        public string pType { get; set; }

        [DisplayName("等級")]

        public Nullable<int> pLv { get; set; }

        [DisplayName("血量")]

        public Nullable<int> pHp { get; set; }

        [DisplayName("攻擊")]

        public Nullable<int> pAtk { get; set; }

        [DisplayName("防禦")]

        public Nullable<int> pDef { get; set; }

        [DisplayName("速度")]

        public Nullable<int> pSpeed { get; set; }

        [DisplayName("招式")]

        public string pMoves { get; set; }
    }
}