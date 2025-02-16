using Microsoft.AspNetCore.Mvc;

public class ContactManagementController : BaseController
{
    private IStorage storage;

    public ContactManagementController(IStorage storage)
    {
        this.storage = storage;
    }

    /// <summary>
    /// Создать новый контакт
    /// </summary>
    [HttpPost("contacts")]
    public IActionResult Create([FromBody] Contact contact)
    {
        Contact res = storage.Add(contact);
        if (res!=null)return Created($"/contacts/{contact.Id}", contact);
        return Conflict($"Контакт уже существует");
    }

    /// <summary>
    /// Получить список контактов
    /// </summary>
    [HttpGet("contacts")]
    public ActionResult<List<Contact>> GetContacts()
    {
        return Ok(storage.GetContacts());
    }

    /// <summary>
    /// Получить контакт по идентификатору
    /// </summary>
    [HttpGet("contacts/{id}")]
    public IActionResult GetContactById(int id)
    {
        if (id < 0)
        {
            return BadRequest("Неверный формат идентификатора контакта");
        }

        Contact res = storage.GetContactById(id);
        if (res != null) return Ok(res);
        return NotFound($"Контакт {id} не найден");
    }

    /// <summary>
    /// Редактировать контакт
    /// </summary>
    [HttpPut("contacts/{id}")]
    public IActionResult UpdateContact([FromBody] ContactDto contactDto, int id)
    {
        bool res = storage.UpdateContact(contactDto, id);
        if (res) return Ok();
        return Conflict($"Контакт {id} не найден");
    }

    /// <summary>
    /// Удалить контакт по идентификатору
    /// </summary>
    [HttpDelete("contacts/{id}")]
    public IActionResult DeleteContact(int id)
    {
        bool res = storage.Remove(id);
        if (res) return NoContent();
        return BadRequest($"Такого id {id} не существует");

    }

}

