import { RmsappModule } from './rmsapp.module';

describe('RmsappModule', () => {
  let rmsappModule: RmsappModule;

  beforeEach(() => {
    rmsappModule = new RmsappModule();
  });

  it('should create an instance', () => {
    expect(rmsappModule).toBeTruthy();
  });
});
