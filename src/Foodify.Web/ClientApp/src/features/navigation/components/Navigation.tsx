import { Link } from "react-router-dom";

import { NAVIGATION_ITEMS, ROUTES, Search } from "features";

function Navigation() {
  return (
    <nav className="border-gray-200 bg-white pb-[50px]">
      <div className="mx-auto flex max-w-screen-xl flex-wrap items-center justify-between p-4">
        <div className="flex cursor-pointer items-center space-x-3 rtl:space-x-reverse">
          <Link
            to={ROUTES.HOME}
            className="block rounded px-3 py-2 text-gray-900 hover:bg-gray-100 md:p-0 md:hover:bg-transparent md:hover:text-blue-700"
            aria-current="page"
          >
            <span className="self-center whitespace-nowrap text-2xl font-semibold">Foodify</span>
          </Link>
        </div>

        <Search />

        <div className="hidden w-full items-center justify-between md:order-1 md:flex md:w-auto" id="navbar-search">
          <div className="relative mt-3 md:hidden">
            <div className="pointer-events-none absolute inset-y-0 start-0 flex items-center ps-3">
              <svg
                className="h-4 w-4 text-gray-500"
                aria-hidden="true"
                xmlns="http://www.w3.org/2000/svg"
                fill="none"
                viewBox="0 0 20 20"
              >
                <path
                  stroke="currentColor"
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  strokeWidth="2"
                  d="m19 19-4-4m0-7A7 7 0 1 1 1 8a7 7 0 0 1 14 0Z"
                />
              </svg>
            </div>

            <input
              type="text"
              id="search-navbar"
              className="block w-full rounded-lg border border-gray-300 bg-gray-50 p-2 ps-10 text-sm text-gray-900 focus:border-blue-500 focus:ring-blue-500"
              placeholder="Search..."
            ></input>
          </div>

          <div className="mt-4 rounded-lg border border-gray-100 bg-gray-50 p-4 font-medium md:mt-0 md:flex-row md:space-x-8 md:border-0 md:bg-white md:p-0 rtl:space-x-reverse">
            <div className="flex gap-10">
              {NAVIGATION_ITEMS.map(item => (
                <Link
                  key={item.id}
                  to={item.link}
                  className="block rounded px-3 py-2 text-gray-900 hover:bg-gray-100 md:p-0 md:hover:bg-transparent md:hover:text-blue-700"
                  aria-current="page"
                >
                  {item.name}
                </Link>
              ))}
            </div>
          </div>
        </div>
      </div>
    </nav>
  );
}

export { Navigation };
