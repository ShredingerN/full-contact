using Microsoft.AspNetCore.Mvc;

public class ContactManagementController : BaseController
{
    private ContactStorage contactStorage;

    public ContactManagementController(ContactStorage contactStorage)
    {
        this.contactStorage = contactStorage;
    }

    [HttpPost("contacts")]
    public IActionResult Create([FromBody] Contact contact)
    {
        bool res = contactStorage.Add(contact);
        if (res) return Created($"/contacts/{contact.Id}", contact);
        return Conflict($"Контакт уже существует");
    }

    [HttpGet("contacts")]
    public ActionResult<List<Contact>> GetContacts()
    {
        return Ok(contactStorage.GetContacts());
    }

    [HttpGet("contacts/{id}")]
    public IActionResult SearchContact(int id)
    {
        if (id < 0)
        {
            return BadRequest("Неверный формат идентификатора контакта");
        }

        Contact res = contactStorage.SearchContact(id);
        if (res != null) return Ok(res);
        return NotFound($"Контакт {id} не найден");
    }

    [HttpPut("contacts/{id}")]
    public IActionResult UpdateContact([FromBody] ContactDto contactDto, int id)
    {
        bool res = contactStorage.UpdateContact(contactDto, id);
        if (res) return Ok();
        return Conflict($"Контакт {id} не найден");
    }


    [HttpDelete("contacts/{id}")]
    public IActionResult DeleteContact(int id)
    {
        bool res = contactStorage.Remove(id);
        if (res) return NoContent();
        return BadRequest($"Такого id {id} не существует");

    }

}

