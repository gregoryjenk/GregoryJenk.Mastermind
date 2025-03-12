export abstract class BaseEntityViewModel<VmId> {
    public id: VmId;

    public created: Date;

    public updated: Date | null;

    public deleted: Date | null;

    public version: number;
}