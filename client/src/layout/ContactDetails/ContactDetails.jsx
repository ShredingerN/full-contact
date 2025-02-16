import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams, useNavigate } from 'react-router-dom';

const baseApiUrl = process.env.REACT_APP_API_URL;

const ContactDetails = () => {
    const [contact, setContact] = useState({ name: "", email: "", phone: "", });
    const { id } = useParams();
    const navigate = useNavigate();

    useEffect(() => {
        const url = `${baseApiUrl}/contacts/${id}`;
        axios.get(url).then(
            response => setContact(response.data)

        ).catch(
            err => navigate("/")
        )
    }, [id, navigate]);

    const handleDelete = () => {
        const url = `${baseApiUrl}/contacts/${id}`;
        if (window.confirm("Точно грохаем?")) {
            axios.delete(url).then(
                navigate('/')
            ).catch(
                console.log("Ошибка удаления")
            )
        }
    }

    const handleUpdate = () => {
        const url = `${baseApiUrl}/contacts/${id}`;
        axios.put(url, contact).then(
            navigate('/') // Перенаправление на страницу со списком контактов
        ).catch(
            console.log("Ошибка обновления")
        )
    }

    return (<div className="container mt-5">
        <h2>Детали контакта</h2>
        <div className="mb-3">
            <label className="form-label">Имя:</label>
            <input
                type="text"
                className="form-control"
                value={contact.name}
                onChange={(e) => { setContact({ ...contact, name: e.target.value }) }}
            />
        </div>
        <div className="mb-3">
            <label className="form-label">Email:</label>
            <input
                type="email"
                value={contact.email}
                className="form-control"
                onChange={(e) => { setContact({ ...contact, email: e.target.value }) }}
            />
        </div>
        <div className="mb-3">
            <label className="form-label">Телефон:</label>
            <input
                type="tel"
                value={contact.phone}
                className="form-control"
                onChange={(e) => { setContact({ ...contact, phone: e.target.value }) }}
            />
        </div>
        <div>
            <button
                type="submit"
                className="btn btn-primary me-2"
                onClick={handleUpdate}>
                Обновить
            </button>

            <button
                type="submit"
                className="btn btn-danger me-2"
                onClick={handleDelete}>
                Удалить
            </button>

            <button
                type="submit"
                className="btn btn-secondary me-2"
                onClick={(e) => { navigate('/') }}>
                Назад
            </button>
        </div>

    </div>)
}

export default ContactDetails;