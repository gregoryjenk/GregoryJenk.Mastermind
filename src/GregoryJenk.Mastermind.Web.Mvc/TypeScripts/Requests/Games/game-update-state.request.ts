export class GameUpdateStateRequest {
    public id: string;

    public version: number;

    public state: GameState;

    public decoderUserId: string;
}