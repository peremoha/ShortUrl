import Home from "./components/Home/Home";
import Registera from "./components/Register/Registera"
import Login from "./components/Login/Login"

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/register',
    element: <Registera />
  },
  {
    path: '/login',
    element: <Login />
  },
];

export default AppRoutes;
