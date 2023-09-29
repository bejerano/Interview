import { Suspense, lazy, useEffect, useState } from 'react'
import './App.css'
import { Route, Routes } from 'react-router-dom';
import routes from './routes';
import Loader from './components/loader/Loader';
import Home from './page/Home';


const DefaultLayout = lazy(() => import('./components/layout/Layout'));

function App() {
  const [loading, setLoading] = useState<boolean>(true);

  useEffect(() => {
    setTimeout(() => setLoading(false), 1000);
  }, []);

  return loading ? (
    <Loader />
  ) : (
    <Routes>
      <Route element={<DefaultLayout />}>
      <Route index element={<Home />} />
        {routes.map(({ path, component: Component }) => (
          <Route
            path={path}
            element={
              <Suspense fallback={<Loader />}>
                <Component />
              </Suspense>
            }
          />
        ))}
      </Route>
    </Routes>
  )
}

export default App
