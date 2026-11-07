program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TSpiralRc = class refc: LongInt; procedure DropFields; virtual; end;
  TMut0 = class;
  TBoxArray0 = class;
  TMut0 = class(TSpiralRc) l0: LongInt; end;
  TBoxArray0 = class(TSpiralRc) items: array of TMut0; procedure DropFields; override; end;
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
function MutCreate0(a0: LongInt): TMut0;
begin
  Result := TMut0.Create; Result.l0 := a0;
end;
procedure TBoxArray0.DropFields;
var i: Int64;
begin
  for i := 0 to High(items) do begin SpiralRelease(items[i]); end;
end;
function SpiralMain: LongInt;
var
  v0: TBoxArray0;
  tmp1: TBoxArray0;
  v1: TMut0;
  v2: TMut0;
  v3: LongInt;
  v4: Boolean;
begin
  tmp1 := TBoxArray0.Create;
  SetLength(tmp1.items, 1);
  v0 := tmp1;
  v1 := MutCreate0(1);
  SpiralRetain(v1); SpiralRelease(v0.items[0]); v0.items[0] := v1;
  SpiralRelease(v1);
  v2 := v0.items[0];
  SpiralRetain(v2);
  SpiralRelease(v0);
  v2.l0 := 7;
  v3 := v2.l0;
  SpiralRelease(v2);
  v4 := v3 = 7;
  if v4 then begin
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
