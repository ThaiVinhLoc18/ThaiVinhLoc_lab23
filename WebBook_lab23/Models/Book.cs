using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebBook_lab23.Models
{
    public class Book
    {
        private int id;
        private string title;
        private string author;
        private string image_cover;
        public Book() { }
        public Book(int id, string title, string author, string image_cover)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.image_cover = image_cover;
        }
        public int Id
        {
            get { return id; }
        }
        [Required(ErrorMessage ="Tiêu đề không được để trống")]
        [StringLength(250, ErrorMessage = "Tiêu đề sách không được vượt quá 250 ký tự")]
        [Display(Name = "Tiêu đề")]
        public string Title
        {
            get { return title; }
            set { value = title; }
        }
        public string Author
        {
            get { return author; }
            set { value = author; }
        }
        public string Image_cover
        {
            get { return image_cover; }
            set { value = image_cover; }
        }
    }
}