import clsx from "clsx";
import { SetStateAction } from "react";

type UserProfileTabsProps = {
  tabItems: { id: string; name: string }[];
  activeTabItemId: string;
  setActiveTabItemId: (value: SetStateAction<string>) => void;
};

function UserProfileTabs({ tabItems, activeTabItemId, setActiveTabItemId }: UserProfileTabsProps) {
  return (
    <div className="relative">
      <div className={clsx("border-gray-300 flex gap-10 border-b")}>
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
              {item.name}
            </p>
            {activeTabItemId === item.id && <div className="border-blue-500 rounded-xs absolute bottom-[-3px] w-full border"></div>}
          </div>
        ))}
      </div>
    </div>
  );
}

export { UserProfileTabs };
