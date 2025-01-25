import TableContact from "./layout/TableContact/TableContact";
import { useState } from 'react';

const App = () => {
  const [contacts, setContacts] = useState(
    [
      // { id: 1, name: 'John Doe', phone: '+1 (123) 456-7890', email: 'john@example.com' },
      // { id: 2, name: 'Jane Doe', phone: '+2 (987) 654-3210', email: 'jane@example.com' },
      // { id: 3, name: 'Michael Johnson', phone: '+3 (555) 123-4567', email: 'michael@example.com' },
      // { id: 4, name: 'Sarah Smith', phone: '+4 (999) 888-7777', email: 'sarah@example.com' },
    ]);

    const addContact = () => {
      const item = {
        id: Math.floor(Math.random() * 100),
        name: 'New Contact',
        phone: '+5 (000) 000-0000',
        email: 'newcontact@example.com',
      };
    
      setContacts([...contacts, item]);
      console.log('New contact added:', item);
    };

  return (
    <div className="container mt-5" >
      <div className="card">
        <div className="card-header">
          <h1>Список контактов</h1>
        </div>
        <TableContact contacts={contacts} />
        <div>
          <button
            className="btn btn-primary"
            onClick={() => { addContact() }}>
            Добавить контакт
          </button>
        </div>
        <div className="card-body">
        </div>
      </div>
    </div>

  );
}

export default App;
