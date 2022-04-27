﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterId { get; set; }

        [StringLength(50)]
        public string WriterName { get; set; }

        [StringLength(50)]
        public string WriterSurName { get; set; }

        [StringLength(250)]
        public string WriterImage { get; set; }
        [StringLength(100)]
        public string WriterAbout { get; set; }

        [StringLength(50)]
        public string WriterMail { get; set; }

        [StringLength(20)]
        public string WriterPass { get; set; }
        [
            StringLength(25)]
        public string WriterTitle { get; set; }
        public bool WriterStatus { get; set; }

        //İlişki
        public ICollection<Heading> headings { get; set; }
    public ICollection<Content> contents { get; set; }
        
    }
}
