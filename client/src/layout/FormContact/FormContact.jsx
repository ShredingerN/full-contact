import { useState } from "react";
const FormContact = (props) => {
    const [contactName, setContactName] = useState('');
    const [contactPhone, setContactPhone] = useState('');
    const [contactEmail, setContactEmail] = useState();
    const [errors, setErrors] = useState({ name: '', phone: '', email: '' });

    const validate = () => {
        let isValid = true;
        const newErrors = { name: '', phone: '', email: '' };

        if (!contactName.trim()) {
            newErrors.name = 'Имя обязательно для заполнения';
            isValid = false;
        }
        if (!contactPhone.trim()) {
            newErrors.phone = 'Телефон обязателен для заполнения';
            isValid = false;
        }
        if (!contactEmail.trim()) {
            newErrors.email = 'E-mail обязателен для заполнения';
            isValid = false;
        }

        setErrors(newErrors);
        return isValid;
    };

    const submit = () => {
        if (validate()) {
            props.addContact(contactName, contactPhone, contactEmail);
        }
        setContactName('');
        setContactPhone('');
        setContactEmail('');
    };

    return (
        <div>
            <div className="mb-3">
                <form>
                    <div className="mb-1">
                        <label className="form-label"></label>
                        <input className="form-control"
                            type="text"
                            placeholder="Ведите имя:"
                            onChange={(e) => { setContactName(e.target.value) }}
                            value={contactName}
                        />
                        {errors.name && <small className="form-text text-danger">{errors.name}</small>}
                    </div>
                    <div className="mb-1">
                        <label className="form-label"></label>
                        <textarea
                            className="form-control"
                            rows={1}
                            placeholder="Введите телефон:"
                            onChange={(e) => { setContactPhone(e.target.value) }}
                            value={contactPhone}
                        />
                        {errors.phone && <small className="form-text text-danger">{errors.phone}</small>}
                    </div>
                    <div className="mb-1">
                        <label className="form-label"></label>
                        <textarea
                            className="form-control"
                            rows={1}
                            placeholder="Введите e-mail:"
                            value={contactEmail}
                            onChange={(e) => { setContactEmail(e.target.value) }}
                        />
                        {errors.email && <small className="form-text text-danger">{errors.email}</small>}
                    </div>
                </form>
            </div>

            <div>
                <button
                    className="btn btn-primary"
                    onClick={() => { submit() }}>
                    Добавить контакт
                </button>
            </div>
        </div>

    );
}

export default FormContact;