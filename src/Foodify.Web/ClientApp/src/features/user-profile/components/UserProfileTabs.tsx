import clsx from "clsx";
import { SetStateAction } from "react";

import { MealPlanIcon, UserCardIcon } from "assets";
import { USER_PROFILE_TABS } from "features";

type UserProfileTabsProps = {
  tabItems: typeof USER_PROFILE_TABS;
  activeTabItemId: string;
  setActiveTabItemId: (value: SetStateAction<string>) => void;
};

function UserProfileTabs({ tabItems, activeTabItemId, setActiveTabItemId }: Readonly<UserProfileTabsProps>) {
  return (
    <div className="relative">
      <div className={clsx("flex gap-10 border-b border-gray-300")}>
        {tabItems.map(item => (
          <div
            key={item.id}
            className={clsx("group relative border-b-2 border-transparent pb-2 hover:cursor-pointer")}
            onClick={() => setActiveTabItemId(item.id)}
            role={"button"}
            onKeyDown={() => setActiveTabItemId(item.id)}
            tabIndex={0}
          >
            <p
              className={clsx(
                "text-System/Text/Tertiary whitespace-nowrap text-lg font-semibold leading-5",
                activeTabItemId === item.id && "text-blue-500",
                activeTabItemId !== item.id && "group-hover:text-gray-500",
              )}
            >
              {item.icon === "user-details" && <UserCardIcon className="mr-2 inline-block h-6 w-6 fill-slate-100" />}
              {item.icon === "orders" && <MealPlanIcon className="mr-2 inline-block h-6 w-6" />}

              {item.name}
            </p>
            {activeTabItemId === item.id && <div className="rounded-xs absolute bottom-[-3px] w-full border border-blue-500"></div>}
          </div>
        ))}
      </div>
    </div>
  );
}

export { UserProfileTabs };
