import { useQuery } from "@tanstack/react-query";
import "./App.css";

type TProduct = {
  id: string;
  name: string;
  imageUrl: string;
  price: number;
};
function App() {
  const { isPending, error, data, isFetching } = useQuery<TProduct[]>({
    queryKey: ["productData"],
    queryFn: async () => {
      const response = await fetch("http://localhost:5222/api/product/getAll");
      return response.json();
    },
  });
  if (isPending) return "Loading...";

  if (error) return "An error has occurred: " + error.message;

  return (
    <>
      <h1>Hello</h1>
      <h2>World</h2>
      {data?.map((product) => {
        console.log(product);
        const imageUrl = `http://localhost:5222${product.imageUrl}`;
        console.log(imageUrl);
        return (
          <div key={product.id}>
            <h3>{product.name}</h3>
            <p>Price: ${(product.price / 100).toFixed(2)}</p>
            <img src={imageUrl} alt={product.name} width="150" />
          </div>
        );
      })}
    </>
  );
}

export default App;
