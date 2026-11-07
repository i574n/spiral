program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TSpiralRc = class refc: LongInt; procedure DropFields; virtual; end;
  TMut0 = class;
  TMut0 = class(TSpiralRc) l0: LongInt; l1: AnsiString; end;
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
function MutCreate0(a0: LongInt; a1: AnsiString): TMut0;
begin
  Result := TMut0.Create; Result.l0 := a0; Result.l1 := a1;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: AnsiString;
  v2: TMut0;
  v3: LongInt;
  v4: AnsiString;
  v5: LongInt;
  v6: AnsiString;
  v7: Boolean;
  v9: Boolean;
  v8: Boolean;
begin
  v0 := 3;
  v1 := 'no';
  v2 := MutCreate0(v0, v1);
  v3 := 7;
  v4 := 'hi';
  v2.l0 := v3;
  v2.l1 := v4;
  v5 := v2.l0;
  v6 := v2.l1;
  SpiralRelease(v2);
  v7 := v5 = 7;
  if v7 then begin
      v8 := v6 = 'hi';
      v9 := v8;
  end else begin
      v9 := False;
  end;
  if v9 then begin
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
