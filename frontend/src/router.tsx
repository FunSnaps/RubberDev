import { createBrowserRouter, RouterProvider, Outlet } from 'react-router-dom';

import Header from './components/organisms/Header';
import ProfilePage from './components/pages/ProfilePage';
import GamePage from './components/pages/GamePage';

function AppLayout() {
  return (
    <>
      <Header />
      <main style={{ padding: '2rem' }}>
        <Outlet />
      </main>
    </>
  );
}

const router = createBrowserRouter([
  {
    element: <AppLayout />,
    children: [
      { index: true, element: <ProfilePage /> },
      { path: 'game', element: <GamePage /> },
    ],
  },
]);

export default function AppRouter() {
  return <RouterProvider router={router} />;
}