using DotnetAssignment.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using DotnetAssignment.Models;

namespace DotnetAssignment.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)] 
public class IssueController:ControllerBase{
    IIssueService _issueService;
    public IssueController(IIssueService service) {
        _issueService = service;
    }

    [Authorize(Roles="admin,projectManager,standard")]
    [HttpGet]
    [Route("[action]")]
    public IActionResult GetAllIssues() {
        try {
            var issues = _issueService.GetIssuesList();
            Console.WriteLine(issues);
            if (issues == null) return NotFound();
            return Ok(issues);
        } catch (Exception) {
            return BadRequest();
        }
    }

    [Authorize(Roles="admin,projectManager,standard")]
    [HttpGet]
    [Route("[action]/id")]
    public IActionResult GetIssuesById(int id) {
        try {
            var issues = _issueService.GetIssueDetailsById(id);
            if (issues == null) return NotFound();
            return Ok(issues);
        } catch (Exception) {
            return BadRequest();
        }
    }

    [Authorize(Roles="admin,projectManager")]
    [HttpPost]
    [Route("[action]")]
    public IActionResult SaveIssues(TempIssue issueModel) {
        try {
            var model = _issueService.SaveIssue(issueModel);
            return Ok(model);
        } catch (Exception) {
            return BadRequest();
        }
    }

    [Authorize(Roles="admin,projectManager")]
    [HttpDelete]
    [Route("[action]")]
    public IActionResult DeleteIssue(int id) {
        try {
            var model = _issueService.DeleteIssue(id);
            return Ok(model);
        } catch (Exception) {
            return BadRequest();
        }
    }

    [Authorize(Roles="admin,projectManager")]
    [HttpPut]
    [Route("[action]")]
    public IActionResult UpdateIssue(int issueId,IssueUpdate issueModel) {
        try {
            var model = _issueService.UpdateIssue(issueId,issueModel);
            return Ok(model);
        } catch (Exception) {
            return BadRequest();
        }
    }

    [Authorize(Roles="admin,projectManager")]
    [HttpPut]
    [Route("[action]")]
    public IActionResult UpdateStatus(int issueId,string status) {
        try {
            var model = _issueService.UpdateStatus(issueId,status);
            return Ok(model);
        } catch (Exception) {
            return BadRequest();
        }
    }

    [Authorize(Roles="admin,projectManager")]
    [HttpPut]
    [Route("[action]")]
    public IActionResult AssignIssueToUser(int issueId,int userId) {
        try {
            var model = _issueService.AssignIssue(issueId,userId);
            return Ok(model);
        } catch (Exception) {
            return BadRequest();
        }
    }

    [Authorize(Roles="admin,projectManager,standard")]
    [HttpGet]
    [Route("[action]/issueTittle/issueDescription")]

    public IActionResult SearchIssue(string issueTittle, string issueDescription) {

    try { var issues = _issueService.SearchIssue(issueTittle,issueDescription);
            if (issues == null) return NotFound();
                     return Ok(issues);
            } 
            catch (Exception ex) {
                return BadRequest();
                }
                }
}