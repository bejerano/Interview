import { lazy } from 'react';

const Home = lazy(() => import('../page/Home'));
const History = lazy(() => import('../page/History'));
const Payment = lazy(() => import('../page/Payment'));


const coreRoutes = [
  {
    path: '/home',
    title: 'home',
    component: Home,
  },
  {
    path: '/history',
    title: 'history',
    component: History,
  },
  {
    path: '/payment',
    title: 'Payment',
    component: Payment,
  },

];

const routes = [...coreRoutes];
export default routes;