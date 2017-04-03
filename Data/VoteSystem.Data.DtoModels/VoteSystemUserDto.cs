using System;
using System.Collections.Generic;

namespace VoteSystem.Data.DTO
{
    public class VoteSystemUserDto
    {
        public Guid Id { get; set; }
        
        public string Email { get; set; }

        public ICollection<ParticipantDto> Participants { get; set; }
    }
}
