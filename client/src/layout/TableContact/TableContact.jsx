import RowTableContact from "./components/RowTableContact";

const TableContact = (props) => {
    return (

        <table className="table table-hover">
            <thead>
                <tr>
                    <th></th>
                    <th>Имя контакта</th>
                    <th>Телефон</th>
                    <th>E-mail</th>
                </tr>
            </thead>
            <tbody>
                {
                    props.contacts.map(
                        contact =>
                        (<RowTableContact
                            key={contact.id}
                            id={contact.id}
                            name={contact.name}
                            phone={contact.phone}
                            email={contact.email}
                        />)
                    )
                }
            </tbody>
        </table>
    );
}

export default TableContact;