import { AddressIcon, EmailIcon, PhoneIcon, SubscriptionIcon } from "assets";
import { User } from "features";

type UserProfileDetailsProps = {
  user: User;
};

function UserProfileDetails({ user }: UserProfileDetailsProps) {
  return (
    <div className="text-lg">
      <h2 className="text-2xl font-semibold">User Details</h2>
      <p className="flex flex-row items-center gap-1">
        <EmailIcon className="h-6 w-6 fill-slate-100" />
        <span className="font-semibold">Email:</span> <span className="text-blue-400">{user.email}</span>
      </p>
      <p className="flex flex-row items-center gap-1">
        <AddressIcon className="h-6 w-6 fill-slate-500" />
        <span className="font-semibold">Address:</span> <span className="text-blue-400">{user.address}</span>
      </p>
      <p className="flex flex-row items-center gap-1">
        <PhoneIcon className="h-6 w-6 fill-slate-800" />
        <span className="font-semibold">Phone:</span> <span className="text-blue-400">{user.phone}</span>
      </p>
      <p className="flex flex-row items-center gap-1">
        <SubscriptionIcon className="h-6 w-6 fill-slate-800" />
        <span className="font-semibold">Subscription:</span> <span className="text-blue-400">{user.subscriptionType}</span>
      </p>
    </div>
  );
}

export { UserProfileDetails };
