import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import CharacterPage from './components/pages/CharacterPage';
import HomePage from './components/pages/HomePage';
import ProfilePage from './components/pages/ProfilePage/ProfilePage.tsx';

const router = createBrowserRouter([
  { path: '/', element: <HomePage /> },
  { path: '/me', element: <ProfilePage /> },
  { path: '/game', element: <CharacterPage /> },
]);

export default function AppRouter() {
  return <RouterProvider router={router} />;
}
