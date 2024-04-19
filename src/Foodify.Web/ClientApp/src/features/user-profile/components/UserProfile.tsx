import { useState } from "react";

import { USER_PROFILE_TABS, UserProfileDetails, UserProfileOrders, UserProfileTabs, useUser } from "features";
import { useAuthStore } from "stores";

function UserProfile() {
  const [currentTabId, setCurrentTabId] = useState<string>(USER_PROFILE_TABS[0].id);

  const { email } = useAuthStore(state => ({ email: state.email }));
  const user = useUser(email!);

  return (
    <div className="m-auto flex w-[80%] flex-col items-center">
      <h1 className="w-[50%] text-left text-2xl font-extrabold">Profile</h1>

      <div className="mt-10 w-[50%] items-start">
        <UserProfileTabs tabItems={USER_PROFILE_TABS} activeTabItemId={currentTabId} setActiveTabItemId={tab => setCurrentTabId(tab)} />
      </div>

      <div className="grid-row-12 mt-10 grid w-[50%] gap-10">
        {currentTabId === "user-details" && user.isFetched && <UserProfileDetails user={user.data!} />}
        {currentTabId === "orders" && user.isFetched && <UserProfileOrders />}
      </div>
    </div>
  );
}

export { UserProfile };
