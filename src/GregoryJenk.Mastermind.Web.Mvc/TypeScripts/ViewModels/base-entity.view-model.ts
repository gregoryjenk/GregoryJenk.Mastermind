export abstract class BaseEntityViewModel<VmId> {
    public id: VmId;

    public created: Date;

    public updated: Date;

    public deleted: Date;

    public version: number;
}