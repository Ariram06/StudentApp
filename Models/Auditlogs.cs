using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApp.Models;
public class Auditlogs
{
    public long AuditId { get; set; }
    public string EntityName { get; set; } = string.Empty;
    public int EntityId { get; set; }
    public string Action { get; set; } = string.Empty;
    public string? Details { get; set; }
    public DateTime CreatedAt { get; set; }

    public Auditlogs(long auditId, string entityName, int entityId, string action, string? details, DateTime createdAt)
    {
        AuditId = auditId;
        EntityName = entityName;
        EntityId = entityId;
        Action = action;
        Details = details;
        CreatedAt = createdAt;
    }
}
