const App = () => {
  return (
    <div className = "container mt-5" >
      <div className = "card">
        <div className = "card-header">
          <hi>Список контактов</hi>
        </div>
        
        <div className = "card-body">
          <table className="table table-hover">
            <thead>
              <tr>
                <th>№</th>
                <th>Имя контакта</th>
                <th>Телефон</th>
                <th>E-mail</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <th>1</th>
                <th>fff</th>
                <th>fff</th>
                <th>fff</th>
              </tr>

              <tr>
                <th>2</th>
                <th>ffff</th>
                <th>sss</th>
                <th>ssss</th>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>

  );
}

export default App;
