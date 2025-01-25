const FormContact = (props) => {
    return (
        <div>
            <div className="mb-3">
                <form>
                    <div className="mb-3">
                        <label className="form-label"></label>
                        <input className="form-control" type="text" placeholder="Ведите имя:" />
                    </div>
                    <div className="mb-3">
                        <label className="form-label"></label>
                        <textarea className="form-control" rows={1} placeholder="Введите e-mail:" />
                    </div>
                </form>
            </div>

            <div>
                <button
                    className="btn btn-primary"
                    onClick={() => { props.addContact() }}>
                    Добавить контакт
                </button>
            </div>
        </div>

    );
}

export default FormContact;