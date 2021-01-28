﻿using System.ComponentModel.DataAnnotations;

namespace ClaimManager.Application.DTOs.Identity
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}