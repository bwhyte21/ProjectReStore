import { useState } from 'react';

function App() {
  // We need to store what is inside this component to store this data in memory, using states.
  const [products, setProducts] = useState([
    { name: 'product1', price: 100.0 },
    { name: 'product2', price: 200.0 },
  ]);

  // Add a new product to the list.
  // prevState grants access to what the product was before modification.
  function addProduct() {
    setProducts((prevState) => [
      ...prevState,
      { name: 'product' + (prevState.length + 1), price: prevState.length * 100 + 100 },
    ]);
  }

  return (
    <div>
      <h1>Re-Store</h1>
      <ul>
        {products.map((item, index) => (
          <li key={index}>
            {item.name} - {item.price}
          </li>
        ))}
      </ul>
      <button type="button" onClick={addProduct}>
        Add Product
      </button>
    </div>
  );
}

export default App;
