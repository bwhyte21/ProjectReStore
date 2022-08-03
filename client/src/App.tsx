import { useEffect, useState } from 'react';
import { Product } from './product';

function App() {
  // We need to store what is inside this component to store this data in memory, using states.
  // This const is temporary.
  const [products, setProducts] = useState<Product[]>([]);

  // useEffect hooks allows us to add a side effect to a component when it loads.
  useEffect(() => {
    fetch('https://localhost:5001/api/Products')
      .then((response) => response.json()) // the fetch will give us a json response.
      .then((data) => setProducts(data)); // then we get data from said response.
  }, []); // [] = empty dependency makes this useEffect get called only once. Remember this!

  // Add a new product to the list.
  // prevState grants access to what the product was before modification.
  function addProduct() {
    setProducts((prevState) => [
      ...prevState,
      {
        id: prevState.length + 101,
        name: 'product' + (prevState.length + 1),
        price: prevState.length * 100 + 100,
        brand: 'empty brand',
        description: 'empty description',
        pictureUrl: 'http://picsum.photos/200',
      },
    ]);
  }

  return (
    <div>
      <h1>Re-Store</h1>
      <ul>
        {products.map((product) => (
          <li key={product.id}>
            {product.name} - {product.price}
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
