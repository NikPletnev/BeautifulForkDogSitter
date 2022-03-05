using DogSitter.API.Models.InputModels;
using DogSitter.BLL.Models;
﻿using DogSitter.DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace DogSitter.API.Models
{
    public class OrderUpdateInputModel
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        public DateTime OrderDate { get; set; }
        public int SitterId { get; set; }
        public int SitterWorkTimeId { get; set; }
        public int DogId { get; set; }
        public List<int> ServicesId { get; set; }
    }
}

