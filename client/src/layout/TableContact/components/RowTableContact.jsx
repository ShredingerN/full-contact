const RowTableContact=(props)=>{
    return (
        <tr onClick={()=> {props.deleteContact(props.id)}}>
            <th>{props.id}</th>
            <th>{props.name}</th>
            <th>{props.phone}</th>
            <th>{props.email}</th>
          </tr>
    );
}

export default RowTableContact;