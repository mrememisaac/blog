﻿using System;

namespace EmemIsaac.Blog.Domain.Common
{
    public class Entity : IEntity
    {
        public Guid Id { get; set; }

        public DateTimeOffset CreateDate { get; set; }

        public string CreatorId { get; set; }

        public DateTimeOffset ChangeDate { get; set; }

        public string ChangerId { get; set; }
    }
}
