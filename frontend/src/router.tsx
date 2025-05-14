import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import HomePage from './components/pages/HomePage';
import CharacterPage from './components/pages/CharacterPage';

const router = createBrowserRouter([
  { path: '/', element: <HomePage /> },
  { path: '/characters', element: <CharacterPage /> },
]);

export default function AppRouter() {
  return <RouterProvider router={router} />;
}
