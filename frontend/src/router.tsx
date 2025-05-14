import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import CharacterPage from './components/pages/CharacterPage';
import ProfilePage from './components/pages/ProfilePage.tsx';

const router = createBrowserRouter([
  { path: '/', element: <ProfilePage /> },
  { path: '/game', element: <CharacterPage /> },
]);

export default function AppRouter() {
  return <RouterProvider router={router} />;
}
