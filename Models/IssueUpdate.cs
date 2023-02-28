using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetAssignment.Models;
public class IssueUpdate
    {
        public string? Description { get;set;}

        public string Type {get;set;}
        public string Title {get;set;}
        public int AssigneeId {get;set;}
    }