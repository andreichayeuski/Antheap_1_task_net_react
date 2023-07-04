import { CompanyComponent } from "../components/CompanyComponent";
import { HomeComponent } from "../components/HomeComponent";

const AppRoutes = [
  {
    index: true,
    element: <HomeComponent />
  },
  {
    path: '/company/search',
    element: <CompanyComponent />
  }
];

export default AppRoutes;
