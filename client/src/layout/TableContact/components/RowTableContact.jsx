import { Link } from "react-router-dom";
const RowTableContact = (props) => {

    return (
        <tr >
            <th>{props.id}</th>
            <th>{props.name}</th>
            <th className="d-none d-md-table-cell">{props.phone}</th>
            <th className="d-none d-md-table-cell">{props.email}</th>
            <th>
                <Link
                    to={`/contact/${props.id}`}
                    className='btn btn-primary btm-sm'>
                    Подробнее
                </Link>
            </th>
        </tr>
    );
}

export default RowTableContact;