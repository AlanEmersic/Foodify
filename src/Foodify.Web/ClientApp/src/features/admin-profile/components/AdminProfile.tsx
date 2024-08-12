import { useState } from "react";

import { ADMIN_PROFILE_TABS, ADMIN_PROFILE_TABS_ICONS, AdminProfileTabs, AdminRestaurantList, UserProfileDetails, useUser } from "features";
import { useAuthStore } from "stores";

function AdminProfile() {
  const [currentTabId, setCurrentTabId] = useState<string>(ADMIN_PROFILE_TABS[0].id);

  const { email } = useAuthStore(state => ({ email: state.email }));
  const user = useUser(email!);

  return (
    <div className="m-auto flex w-[80%] flex-col items-center">
      <h1 className="w-[50%] text-left text-2xl font-extrabold">Admin profile</h1>

      <div className="mt-10 w-[50%] items-start">
        <AdminProfileTabs tabItems={ADMIN_PROFILE_TABS} activeTabItemId={currentTabId} setActiveTabItemId={tab => setCurrentTabId(tab)} />
      </div>

      <div className="grid-row-12 mt-10 grid w-[50%] gap-10">
        {currentTabId === ADMIN_PROFILE_TABS_ICONS["admin-details"] && user.isFetched && <UserProfileDetails user={user.data!} />}

        {currentTabId === ADMIN_PROFILE_TABS_ICONS["restaurants"] && user.isFetched && <AdminRestaurantList />}
      </div>
    </div>
  );
}

export { AdminProfile };
