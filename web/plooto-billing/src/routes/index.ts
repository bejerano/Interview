import { lazy } from 'react';

const History = lazy(() => import('../page/History'));
const Payment = lazy(() => import('../page/Payment'));

const coreRoutes = [
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
