using System.Net.Mime;
using BaseASPNETCore.User.Domain.Model.Queries;
using BaseASPNETCore.User.Domain.Services;
using BaseASPNETCore.User.Interfaces.REST.Resources;
using BaseASPNETCore.User.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BaseASPNETCore.User.Interfaces.REST; 

[Route("api/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Tags("User Management - Autor: Grupo Manyas")]
public class UserController(
    IUserCommandServices userCommandServices,
    IUserQueryServices userQueryServices) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a user",
        Description = "Creates a user with the provided details",
        OperationId = "CreateUser")]
    [SwaggerResponse(201, "The user was created successfully", typeof(UserResources))]
    [SwaggerResponse(400, "The user was not created due to validation errors")]
    public async Task<ActionResult> CreateUser([FromBody] CreateUserResources resources)
    {
        var CreateNewUserCommand = CreateUserCommandFromResourceAssembler.ToCommandFromResource(resources);
        var result = await userCommandServices.Handle(CreateNewUserCommand);
        // Mensaje de error si el usuario no se pudo crear
        if (result is null) return BadRequest("User creation failed. Please check the provided details.");
        return CreatedAtAction(nameof(GetUserById), new { id = result.Id }, UserResourceFromEntityAsembler.ToResourceFromEntity(result));
    }
    
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Gets a user by ID",
        Description = "Retrieves a user based on the provided ID",
        OperationId = "GetUserById")]
    [SwaggerResponse(200, "The user was found", typeof(UserResources))]
    [SwaggerResponse(404, "The user was not found")]
    public async Task<ActionResult> GetUserById(int id)
    {
        var getUserByIdQuery = new GetUserByIdQueries(id); 
        var result = await userQueryServices.Handle(getUserByIdQuery);
        if (result is null) return NotFound($"User with ID {id} not found.");
        var resource = UserResourceFromEntityAsembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
}