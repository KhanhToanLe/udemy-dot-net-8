using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using UdemyWebApp8.CustomValidate;

namespace UdemyWebApp8.Model.Entity
{
    [ValidateNever]
    public class Song
    {
        public Guid SongId { get; set; }
        [Required]
        [MaxLength(12)]
        [DisplayName("Song title")]
        [StringLength(30, MinimumLength=12,ErrorMessage ="{0} length have to in the middle of {2} and {1}")]
        [RegularExpression(@"^W.*$")]
        [BindNever]
        public string SongName { get; set; } = "";
        [Range(12,30,ErrorMessage ="{0} should be had value between {1} and {2}")]
        public int SongAge { get; set; }
        [Required(ErrorMessage ="required {0}")]
        [EmailAddress(ErrorMessage ="Email's not appropriate")]
        public string AuthorEmail { get; set; } = "";
        [Phone(ErrorMessage="Phone is wrong")]
        public string AuthorPhone { get; set; } = "";
        [Compare("PrivateSongCodeRepeat",ErrorMessage ="not the same, check it again")]
        public string PrivateSongCode { get; set; } = "";
        public string PrivateSongCodeRepeat { get; set; } = "";
        [CustomValidate1]
        [DisplayName("Song Time")]
        public string SongTime { get; set; } = "";
        public List<string> ListOfHasTag { get; set; } = new List<string>();

        public override string ToString()
        {
            var toStringVal = $"{SongName} {SongAge} {AuthorEmail} {AuthorPhone} {PrivateSongCode} {PrivateSongCodeRepeat} {SongTime}";
            Console.WriteLine(toStringVal);
            return toStringVal;
        }
    }
}
