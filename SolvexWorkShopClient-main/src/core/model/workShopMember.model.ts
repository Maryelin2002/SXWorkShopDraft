import { WorkShopMemberRole } from "@/core/utils/enums";
import { BaseEntity } from "./base.model";

export interface WorkShopMember extends BaseEntity {
    role: WorkShopMemberRole;
    workShopId: number;
    userId: number;
}