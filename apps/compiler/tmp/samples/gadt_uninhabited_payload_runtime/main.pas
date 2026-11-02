program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TSpiralRc = class refc: LongInt; procedure DropFields; virtual; end;
  TUH0 = class;
  TUH1 = class;
  TUH2 = class;
  TUH0 = class(TSpiralRc) tag: LongInt;  end;
  TUH1 = class(TSpiralRc) tag: LongInt;  end;
  TUH2 = class(TSpiralRc) tag: LongInt; c0_0: TUH0; c0_1: TUH1; procedure DropFields; override; end;
procedure TSpiralRc.DropFields;
begin
end;
procedure SpiralRetain(o: TSpiralRc);
begin
  if o <> nil then Inc(o.refc);
end;
procedure SpiralRelease(o: TSpiralRc);
begin
  if o <> nil then begin Dec(o.refc); if o.refc < 0 then begin o.DropFields; o.Free; end; end;
end;
var UH0_PayloadZero_shared: TUH0 = nil;
function UH0_PayloadZero: TUH0;
begin
  if UH0_PayloadZero_shared = nil then begin UH0_PayloadZero_shared := TUH0.Create; UH0_PayloadZero_shared.tag := 0; UH0_PayloadZero_shared.refc := High(LongInt) div 2; end;
  Result := UH0_PayloadZero_shared;
end;
var UH1_PayloadRowNil_shared: TUH1 = nil;
function UH1_PayloadRowNil: TUH1;
begin
  if UH1_PayloadRowNil_shared = nil then begin UH1_PayloadRowNil_shared := TUH1.Create; UH1_PayloadRowNil_shared.tag := 0; UH1_PayloadRowNil_shared.refc := High(LongInt) div 2; end;
  Result := UH1_PayloadRowNil_shared;
end;
procedure TUH2.DropFields;
begin
  SpiralRelease(c0_0); SpiralRelease(c0_1);
end;
function UH2_PayloadRowCons(a0: TUH0; a1: TUH1): TUH2;
begin
  Result := TUH2.Create; Result.tag := 0; Result.c0_0 := a0; Result.c0_1 := a1;
end;
function SpiralMain: LongInt;
var
  v0: TUH0;
  v1: TUH0;
  v2: TUH1;
  v3: TUH2;
  v7: TUH0;
  v4: TUH0;
  v5: TUH1;
  v8: Boolean;
begin
  v0 := UH0_PayloadZero;
  v1 := UH0_PayloadZero;
  v2 := UH1_PayloadRowNil;
  v3 := UH2_PayloadRowCons(v1, v2);
  case v0.tag of
      0: begin
          case v3.tag of
              0: begin
                  v4 := v3.c0_0;
                  v5 := v3.c0_1;
                  v7 := v4;
              end;
          end;
      end;
  end;
  case v7.tag of
      0: begin
          v8 := True;
      end;
  end;
  if v8 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
