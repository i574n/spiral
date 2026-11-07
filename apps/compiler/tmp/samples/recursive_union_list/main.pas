program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TSpiralRc = class refc: LongInt; procedure DropFields; virtual; end;
  TUH0 = class;
  TUH0 = class(TSpiralRc) tag: LongInt; c1_0: LongInt; c1_1: TUH0; procedure DropFields; override; end;
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
function SpiralKeep(o: TSpiralRc): TSpiralRc;
begin
  SpiralRetain(o); Result := o;
end;
function sum_0(v0: TUH0): LongInt; forward;
procedure TUH0.DropFields;
begin
  SpiralRelease(c1_1);
end;
var UH0_Nil_shared: TUH0 = nil;
function UH0_Nil: TUH0;
begin
  if UH0_Nil_shared = nil then begin UH0_Nil_shared := TUH0.Create; UH0_Nil_shared.tag := 0; UH0_Nil_shared.refc := High(LongInt) div 2; end;
  Result := UH0_Nil_shared;
end;
function UH0_Cons(a0: LongInt; a1: TUH0): TUH0;
begin
  Result := TUH0.Create; Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
function sum_0(v0: TUH0): LongInt;
var
  v1: LongInt;
  v2: TUH0;
  v3: LongInt;
  v4: LongInt;
begin
  case v0.tag of
      1: begin
          v1 := v0.c1_0;
          v2 := v0.c1_1;
          SpiralRetain(v2);
          SpiralRetain(v2);
          SpiralRelease(v0);
          v3 := sum_0(v2);
          SpiralRelease(v2);
          v4 := v1 + v3;
          Result := v4;
      end;
      0: begin
          SpiralRelease(v0);
          Result := 0;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v2: LongInt;
  v3: TUH0;
  v4: TUH0;
  v5: TUH0;
  v6: TUH0;
  v7: LongInt;
  v8: LongInt;
begin
  v0 := 1;
  v1 := 2;
  v2 := 3;
  v3 := UH0_Nil;
  SpiralRetain(v3);
  v4 := UH0_Cons(v2, v3);
  SpiralRetain(v4);
  SpiralRelease(v3);
  v5 := UH0_Cons(v1, v4);
  SpiralRetain(v5);
  SpiralRelease(v4);
  v6 := UH0_Cons(v0, v5);
  SpiralRetain(v6);
  SpiralRelease(v5);
  v7 := sum_0(v6);
  SpiralRelease(v6);
  v8 := v7 - 6;
  Result := v8;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
var SpiralExitCode: LongInt;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  SpiralExitCode := SpiralMain;
  if UH0_Nil_shared <> nil then UH0_Nil_shared.Free;
  Halt(SpiralExitCode);
end.
