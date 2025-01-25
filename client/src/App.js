import TableContact from "./layout/TableContact/TableContact";

const App = () => {
  return (
    <div className = "container mt-5" >
      <div className = "card">
        <div className = "card-header">
          <h1>Список контактов</h1>
        </div>
        <TableContact/>
        <div className = "card-body">
        </div>
      </div>
    </div>

  );
}

export default App;
